using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using Newtonsoft.Json;
using CVIMS.Api.Infrastructure.Config;
using Microsoft.Extensions.Options;

namespace CVIMS.Api.Features.Payments
{
    [Produces("application/json")]
    [Route("api/Payments")]
    public class PaymentsController : Controller
    {
        private readonly IMapper _mapper;
        private readonly SquarePaymentConfigModel _sqConfig;

        public PaymentsController(IMapper mapper, IOptions<SquarePaymentConfigModel> sqConfig)
        {
            _mapper=mapper;
            _sqConfig = sqConfig.Value;
        }

        [HttpPost("Charge")]
        public async Task<PaymentsResponse> ChargeNonce([FromBody]PaymentsModel model)
        {
            ChargeRequest body = new ChargeRequest();
            SetTestValues(body);

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://connect.squareup.com");
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + _sqConfig.Token);
            client.DefaultRequestHeaders.Add("Accept", "application/json");

            string stringData = JsonConvert.SerializeObject(body);
            var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");
            var response = await client.PostAsync("/v2/locations/" + _sqConfig.LocationId + "/transactions", contentData);
            var contents = await response.Content.ReadAsStringAsync();
            var paymentResponse = JsonConvert.DeserializeObject<PaymentsResponse>(contents);

            return paymentResponse;
        }

        private void SetTestValues(ChargeRequest body)
        {
            body.Idempotency_key = "D72B07DD-2F95-4CDC-B415-13B59608E238";
            body.Amount_money = new Money()
            {
                Amount = 123,
                Currency = "USD"
            };
            body.Card_nonce = "CBASEIJ8hPSkcJozfeCxUwjo7TEgAQ";
            body.Delay_capture = false;
        }
    }
}

// Ex. Request
//{
//  "idempotency_key": "74ae1696-b1e3-4328-af6d-f1e04d947a13",
//  "shipping_address": {
//    "address_line_1": "123 Main St",
//    "locality": "San Francisco",
//    "administrative_district_level_1": "CA",
//    "postal_code": "94114",
//    "country": "US"
//  },
//  "billing_address": {
//    "address_line_1": "500 Electric Ave",
//    "address_line_2": "Suite 600",
//    "administrative_district_level_1": "NY",
//    "locality": "New York",
//    "postal_code": "10003",
//    "country": "US"
//  },
//  "amount_money": {
//    "amount": 200,
//    "currency": "USD"
//  },
//  "additional_recipients": [
//    {
//      "location_id": "057P5VYJ4A5X1",
//      "description": "Application fees",
//      "amount_money": {
//        "amount": 20,
//        "currency": "USD"
//      }
//    }
//  ],
//  "card_nonce": "card_nonce_from_square_123",
//  "reference_id": "some optional reference id",
//  "note": "some optional note",
//  "delay_capture": false
//}


    // Ex Response
//    {
//  "transaction": {
//    "id": "KnL67ZIwXCPtzOrqj0HrkxMF",
//    "location_id": "18YC4JDH91E1H",
//    "created_at": "2016-03-10T22:57:56Z",
//    "tenders": [
//      {
//        "id": "MtZRYYdDrYNQbOvV7nbuBvMF",
//        "location_id": "18YC4JDH91E1H",
//        "transaction_id": "KnL67ZIwXCPtzOrqj0HrkxMF",
//        "created_at": "2016-03-10T22:57:56Z",
//        "note": "some optional note",
//        "amount_money": {
//          "amount": 200,
//          "currency": "USD"
//        },
//        "additional_recipients": [
//          {
//            "location_id": "057P5VYJ4A5X1",
//            "description": "Application fees",
//            "amount_money": {
//              "amount": 20,
//              "currency": "USD"
//            },
//            "receivable_id": "ISu5xwxJ5v0CMJTQq7RvqyMF"
//          }
//        ],
//        "type": "CARD",
//        "card_details": {
//          "status": "CAPTURED",
//          "card": {
//            "card_brand": "VISA",
//            "last_4": "1111"
//          },
//          "entry_method": "KEYED"
//        }
//      }
//    ],
//    "reference_id": "some optional reference id",
//    "product": "EXTERNAL_API"
//  }
//}