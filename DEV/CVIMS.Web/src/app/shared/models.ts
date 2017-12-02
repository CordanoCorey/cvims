import { Validators } from '@angular/forms';
import { build, EMAIL_REGEX, Metadata, Token } from '@caiu/core';
import { LookupValue } from '@caiu/http';

export class BaseEntity {
    id = 0;
    createdById = '';
    createdDate?: Date = new Date();
    formId = 0;
    lastModifiedById?= '';
    lastModifiedDate?: Date = new Date();
    matches: string[] = [];
    _ignore = [
        'createdById',
        'createdDate',
        'formId',
        'lastModifiedById',
        'lastModifiedDate',
        'matches',
        '_ignore',
        '_metadata',
        'getGetters',
        'getSetters',
        'update'
    ];
    _metadata: Metadata = new Metadata();

    get metadata(): Metadata {
        return this._metadata;
    }

    set metadata(value: Metadata) {
        this._metadata = value;
    }

    static getGetters(): string[] {
        return Object.keys(this.prototype).filter(name => {
            return typeof Object.getOwnPropertyDescriptor(this.prototype, name)['get'] === 'function';
        });
    }

    static getSetters(): string[] {
        return Object.keys(this.prototype).filter(name => {
            return typeof Object.getOwnPropertyDescriptor(this.prototype, name)['set'] === 'function';
        });
    }

    getGetters(): string[] {
        return Object.keys(this.constructor.prototype).filter(name => {
            return typeof Object.getOwnPropertyDescriptor(this.constructor.prototype, name)['get'] === 'function';
        });
    }

    getSetters(): string[] {
        return Object.keys(this.constructor.prototype).filter(name => {
            return typeof Object.getOwnPropertyDescriptor(this.constructor.prototype, name)['set'] === 'function';
        });
    }

    update(value: any): BaseEntity {
        return Object.assign(new BaseEntity(), value);
    }
}

export class Config {
    dev = false;
    test?= false;
    staging?= false;
    production = false;
    apiBase = '';
}

export class User {
    id = '';
    email = '';
    firstName = '';
    lastName = '';
    password = '';
    confirmPassword = '';
    userName = '';
    _metadata: Metadata = {};
    get metadata(): Metadata {
        return build(Metadata, this._metadata, {
            ignore: [],
            email: {
                validators: [Validators.pattern(EMAIL_REGEX)]
            }
        });
    }

    set metadata(value: Metadata) {
        this._metadata = value;
    }

    get fullName(): string {
        return `${this.firstName} ${this.lastName}`;
    }

    get shippingInfo(): ShippingInfo {
        return build(ShippingInfo, {

        });
    }

    set shippingInfo(value: ShippingInfo) {

    }

}

export class CurrentUser extends User {

    guestId = '';
    token: Token = new Token();

    get authenticated(): boolean {
        return this.token.expires_in > 0;
    }

    get userId(): string {
        return this.authenticated ? this.id : this.guestId;
    }
}

export class Contact {
  name = '';
  email = '';
  phone = '';
  comments= '';
}

export class Login {
    grant_type = 'password';
    username = '';
    password = '';
}

export class QueryItem {
    label = '';
    value: any;
}

export class ResetPassword {
    passwordResetCode = '';
    password = '';
    confirmPassword = '';
}

export class ShippingInfo {
    shippingOptionId = 1;
    storePickup: StorePickup = new StorePickup();
    shipToAddress: ShipToAddress = new ShipToAddress();
    shipToBuilding: ShipToBuilding = new ShipToBuilding();
    storeAddress: Address = new Address();
    buildingAddress: Address = new Address();
    metadata: Metadata = {
        ignore: ['shippingAddress', 'storeAddress', 'buildingAddress'],
        firstName: {},
        lastName: {},
        streetAddress: {},
        address2: {},
        city: {},
        stateId: {},
        zipCode: {},
        homePhone: {},
        cellPhone: {}
    };

    static Address(info: ShippingInfo): Address {
        const value = ShippingInfo.Build(info);
        switch (value.shippingOptionId) {
            case 1:
                return build(Address, value.storeAddress);
            case 2:
                return build(Address, value.shippingAddress);
            case 3:
                return build(Address, value.buildingAddress);
            default:
                return new Address();
        }
    }

    static Build(info: ShippingInfo): ShippingInfo {
        const shipToAddress = ShipToAddress.Build(info.shipToAddress);
        return build(ShippingInfo, info, { shipToAddress });
    }

    get shippingAddress(): Address {
        return this.shipToAddress.address;
    }

}

export class Address {
    streetAddress = '';
    address2 = '';
    city = '';
    stateId = 0;
    zipCode = 0;
    metadata: Metadata = {
        streetAddress: {},
        address2: {},
        city: {},
        stateId: {},
        zipCode: {}
    };
}

export class ShipToAddress {
    firstName = '';
    lastName = '';
    streetAddress = '';
    address2 = '';
    city = '';
    stateId = 0;
    zipCode = 0;
    homePhone = 0;
    cellPhone = 0;
    metadata: Metadata = {
        ignore: ['address'],
        firstName: {},
        lastName: {},
        streetAddress: {},
        address2: {},
        city: {},
        stateId: {},
        zipCode: {},
        homePhone: {},
        cellPhone: {}
    };

    static Build(value: ShipToAddress): ShipToAddress {
        return build(ShipToAddress, value);
    }

    get address(): Address {
        return build(Address, {
            streetAddress: this.streetAddress,
            address2: this.address2,
            city: this.city,
            stateId: this.stateId,
            zipCode: this.zipCode
        });
    }
}

export class ShipToBuilding {
    firstName = '';
    lastName = '';
    buildingName = '';
    email = '';
    metadata: Metadata = {
        firstName: {},
        lastName: {},
        buildingName: {},
        email: {
            // validators: [Validators.email]
        }
    };
}

export class StorePickup {
    firstName = '';
    lastName = '';
    email = '';
    metadata: Metadata = {
        firstName: {},
        lastName: {},
        email: {
            // validators: [Validators.email]
        }
    };
}

export type SiteLocation = 'school-store' | 'supply-store' | 'warehouse';
