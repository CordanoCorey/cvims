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
    shipToAddress: ShipToAddress = new ShipToAddress();
    shipToBuilding: ShipToBuilding = new ShipToBuilding();
}

export class ShipToAddress {
    firstName = '';
    lastName = '';
    streetAddress = '';
    city = '';
    stateId = 0;
    zipCode = 0;
    homePhone = 0;
    cellPhone = 0;
    metadata: Metadata = {
        firstName: {},
        lastName: {},
        streetAddress: {},
        city: {},
        stateId: {},
        zipCode: {},
        homePhone: {},
        cellPhone: {}
    };
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
            validators: [Validators.email]
        }
    };
}

export type SiteLocation = 'school-store' | 'supply-store' | 'warehouse';
