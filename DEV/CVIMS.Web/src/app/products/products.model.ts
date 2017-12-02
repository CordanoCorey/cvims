import { Collection, Metadata, QueryModel, build } from '@caiu/core';
import { integerValidator } from '@caiu/forms';

import { BaseEntity, QueryItem } from '../shared/models';
import { findSiteLocationName } from '../shared/utils';
import { Validators } from '@angular/forms';

export class Product extends BaseEntity {
    additionalInfo = '';
    attribute = '';
    categoryId = 0;
    cost = 0;
    departmentTypeId = 0;
    isActive = false;
    isTaxable = false;
    productTitle = '';
    productDescription = '';
    quantityAvailable = 0;
    quantityInStock = 0;
    retailPrice = 0;
    sale = 0;
    salePrice = 0;
    schoolStore = false;
    staffStore = false;
    sizeId = 0;
    sizeName = '';
    sku = '';
    upc = '';
    upc2 = '';
    vendorName = '';
    warehouseLocation = '';
    webKeywords = '';

    cartItemId = 0;
    isFavorite = false;
    quantityInCart = 0;

    get metadata(): Metadata {
        return {
            ignore: ['productDescription', 'siteLocationId', 'sizeName'],
            view: ['productName', 'retailPrice', 'sizeName'],
            additionalInfo: {},
            attribute: {},
            categoryId: {},
            cost: {},
            departmentTypeId: {},
            isActive: {},
            isTaxable: {},
            productTitle: {},
            productDescription: {},
            quantityAvailable: {},
            quantityInStock: {},
            retailPrice: {},
            sale: {},
            salePrice: {},
            schoolStore: {},
            staffStore: {},
            sizeId: {},
            sku: {},
            upc: {},
            upc2: {},
            vendorName: {},
            warehouseLocation: {},
            webKeywords: {}
        };
    }

    get isInCart(): boolean {
        return !(this.cartItemId === 0);
    }

    get link(): string {
        return `/${this.siteLocationName}/products/${this.id}`;
    }

    get productName(): string {
        return this.productTitle || this.productDescription;
    }

    get siteLocationId(): number {
        if (this.schoolStore) {
            return 1;
        } else if (this.staffStore) {
            return 2;
        }
        return 3;
    }

    get siteLocationName(): string {
        return findSiteLocationName(this.siteLocationId);
    }

}

export class Products extends Collection<Product> {

    categoryId = 0;
    siteLocationId = 0;
    take = 0;

    constructor() {
        super(Product);
    }

    get queryModel(): ProductsQuery {
        return ProductsQuery.Build(this);
    }

    get queryString(): string {
        return QueryModel.BuildQueryString(this.queryModel);
    }

    get searchResults(): Product[] {
        return this.filterBy((x, index) =>
            (this.categoryId === 0 ? true : x.categoryId === this.categoryId)
            && x.id !== 0
            && x.siteLocationId === this.siteLocationId);
    }
}

export class ProductsQuery extends QueryModel<Product> {

    products: Products = new Products();

    static Build(products: Products): ProductsQuery {
        return build(ProductsQuery, { products });
    }

    static Params(products: Products): any {
        const categoryIdParam = products.categoryId ? {
            categoryId: products.categoryId
        } : {};
        return Object.assign({}, categoryIdParam);
    }

    static QueryItems(categories, query): QueryItem[] {
        return [
            {
                label: 'Category',
                value: categories.getCategoryLabel(query.categoryId)
            }
        ];
    }

    get categoryId(): number {
        return this.products.categoryId;
    }

    get params(): any {
        return ProductsQuery.Params(this.products);
    }

    set params(value: any) {
    }

}

export class ProductDetails {
    quantity = 1;
    size = 0;

    static Build(product: Product): ProductDetails {
        return build(ProductDetails, {
            quantity: product.quantityInCart,
            size: product.sizeId
        });
    }

    static HasChanged(product: Product, currentValue: ProductDetails): boolean {
        const details = ProductDetails.Build(product);
        return details.quantity !== currentValue.quantity || details.size !== currentValue.size;
    }

    get metadata(): Metadata {
        return build(Metadata, {
            quantity: {
                validators: [Validators.min(0), integerValidator()]
            }
        });
    }

}
