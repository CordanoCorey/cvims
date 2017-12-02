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
