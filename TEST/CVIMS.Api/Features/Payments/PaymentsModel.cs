using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CVIMS.Api.Features.Payments
{
    public class PaymentsModel
    {
        public string Nonce { get; set; }
        public string IdempotencyKey { get; set; }
        public int Amount { get; set; }
    }
    public class PaymentsResponse
    {
        public List<Error> Errors { get; set; }
        public Transaction Transaction { get; set; }
    }

    public class Transaction
    {
        public string Id { get; set; }
        public Address Shipping_address { get; set; }
        public string Client_id { get; set; }
        public string Reference_id { get; set; }
        public List<Tender> Tenders { get; set; }
        public string Created_at { get; set; }
        public string Location_id { get; set; }
        public string Product { get; set; }
        public string Order_id { get; set; }
    }

    public class Tender {
        public string Id { get; set; }
        Money AmountMoney { get; set; }
        public string Note { get; set; }
        public string Created_at { get; set; }
        public string Transaction_id { get; set; }
        public string Location_id { get; set; }
        public CardDetails Card_details { get; set; }
    }

    public class CardDetails
    {
        public string Status { get; set; }
        public string Entry_method { get; set; }
        public Card Card { get; set; }
    }

    public class Card
    {
        public string Card_brand { get; set; }
        public string Last_4 { get; set; }
    }

    public class Error
    {
        public string Category { get; set; }
        public string Code { get; set; }
        public string Detail { get; set; }
        public string Field { get; set; }
    }

    public class ChargeRequest
    {
        public string Idempotency_key { get; set; }
        public ShippingAddess Shipping_address { get; set; }
        public BillingAddress Billing_address { get; set; }
        public Money Amount_money { get; set; }
        public string Card_nonce { get; set; }
        public string Reference_id { get; set; }
        public string Note { get; set; }
        public string Order_id { get; set; }
        public bool Delay_capture { get; set; }
        public string Buyer_email_address { get; set; }

    }
    public class ShippingAddess : Address
    {

    }

    public class BillingAddress : Address
    {
        public string Address_line_2 { get; set; }
    }

    public class Address
    {
        public string Address_line_1 { get; set; }
        public string Locality { get; set; }
        public string Administrative_district_level_1 { get; set; }
        public string Postal_code { get; set; }
        public int Country { get; set; }
    }

    public class Money
    {
        public int Amount { get; set; }
        public string Currency { get; set; }
    }
}
