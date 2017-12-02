import { Validators } from '@angular/forms';
import { Collection, build, Metadata } from '@caiu/core';

import { Product } from '../products/products.model';
import { BaseEntity } from '../shared/models';


export class CartItem extends BaseEntity {
    userId = '';
    orderId = 0;
    productId = 0;
    quantity = 0;

    product: Product = new Product();

    get schoolStore(): boolean {
        return this.product ? this.product.schoolStore : false;
    }

    get staffStore(): boolean {
        return this.product ? this.product.staffStore : false;
    }

    get productName(): string {
        return this.product.productName;
    }

    get retailPrice(): number {
        return this.quantity * (this.product ? this.product.retailPrice : 0);
    }

    get tax(): number {
        return this.product && this.product.isTaxable ? this.quantity * this.retailPrice * .06 : 0;
    }

    get salePrice(): number {
        return this.retailPrice + this.tax;
    }
}

export class Cart extends Collection<CartItem> {

    constructor() {
        super(CartItem);
    }

    get cost(): { subtotal: number, tax: number } {
        return this.asArray.reduce((acc, item) => {
            return {
                subtotal: acc.subtotal + item.retailPrice,
                tax: acc.tax + item.tax
            };
        }, { subtotal: 0, tax: 0 });
    }

    get subtotal(): number {
        return this.cost.subtotal;
    }

    get tax(): number {
        return this.cost.tax;
    }

    get total(): number {
        const cost = this.cost;
        return cost.subtotal + cost.tax;
    }

}

export class CartItemRow {

    constructor(private _cartItem: CartItem) {
    }

    get cartItem(): CartItem {
        return build(CartItem, this._cartItem);
    }

    get lastModifiedDate(): Date {
        return new Date(this.cartItem.lastModifiedDate);
    }

    get productId(): number {
        return this.cartItem.productId;
    }

    get productName(): string {
        return this.cartItem.productName;
    }

    get quantity(): number {
        return this.cartItem.quantity;
    }
}

export class PaymentInfo {
    cardNumber = 0;
    cvv = 0;
    expirationDate: Date = new Date();
    postalCode = 0;
    nonce = '';
}

export class ChargeInfo {
    nonce = '';
    idempotencyKey = '';
    amount = 0;
}


// Ex. Request to square charge endpoint
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
