import { build } from '@caiu/core';
import { LookupValue } from '@caiu/http';

export const SITE_LOCATIONS = [
    build(LookupValue, { id: 0, name: '', label: '' }),
    build(LookupValue, { id: 1, name: 'school-store', label: 'School Store' }),
    build(LookupValue, { id: 2, name: 'supply-store', label: 'Supply Store' }),
    build(LookupValue, { id: 3, name: 'warehouse', label: 'Warehouse' }),
];
