import { Validators } from '@angular/forms';
import { BaseEntity, build, EMAIL_REGEX, Metadata, Token } from '@caiu/core';
import { LookupValue } from '@caiu/http';

export class Config {
    dev = false;
    test?= false;
    staging?= false;
    production = false;
    apiBase = '';
}

export class User extends BaseEntity {
    id = 0;
    email = '';
    firstName = '';
    lastName = '';
    password = '';
    confirmPassword = '';
    userName = '';
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

}

export class CurrentUser extends User {

    token: Token = new Token();

    get authenticated(): boolean {
        return this.token.expires_in > 0;
    }
}

export class Login {
    grant_type = 'password';
    username = '';
    password = '';
}

export class ResetPassword {
    passwordResetCode = '';
    password = '';
    confirmPassword = '';
}
