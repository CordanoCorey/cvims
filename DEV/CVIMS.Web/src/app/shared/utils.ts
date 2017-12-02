import { LookupValue } from '@caiu/http';

import { SITE_LOCATIONS } from './lookup';

export function findSchoolYear(): string {
    const date = new Date();
    const year = date.getFullYear();
    const month = date.getMonth();
    return month >= 7 ? `${year}-${year + 1}` : `${year - 1}-${year}`;
}

export function findSiteLocationById(id: number): LookupValue {
    return SITE_LOCATIONS.find(x => x.id === id) || SITE_LOCATIONS[0];
}

export function findSiteLocationByName(name: string): LookupValue {
    return SITE_LOCATIONS.find(x => x.name === name) || SITE_LOCATIONS[0];
}

export function findSiteLocationName(id: number): string {
    const siteLocation = findSiteLocationById(id);
    return siteLocation.name;
}


export class Emailer {

    static ContactUs(message: string): string {
        return `
            <html>
                You have received a message from a customer.
                <br><br>
                ${message}
            </html>
        `;
    }

    static OrderApproved(): string {
        return `
            <html>

            </html>
        `;
    }

    static OrderCancelled(): string {
        return `
            <html>

            </html>
        `;
    }

    static OrderDenied(): string {
        return `
            <html>

            </html>
        `;
    }

    static OrderPicked(): string {
        return `
            <html>

            </html>
        `;
    }

    static OrderPlaced(): string {
        return `
            <html>

            </html>
        `;
    }

    static OrderShipped(): string {
        return `
            <html>

            </html>
        `;
    }
}
