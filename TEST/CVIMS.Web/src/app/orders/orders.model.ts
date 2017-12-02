import { Collection, Metadata, build, QueryModel } from '@caiu/core';

import { User, BaseEntity } from '../shared/models';

export class Order extends BaseEntity {
    id = 0;
    comments = '';
    deniedById = 0;
    deniedReason = '';
    email = '';
    firstName = '';
    internalComments = '';
    lastName = '';
    location = '';
    orderDate: Date = new Date();
    orderNumber = 0;
    orderProcessDate: Date = new Date();
    orderStatusId = 0;
    phoneExtension = 0;
    pickedById = 0;
    pickedDate: Date = new Date();
    userId = 0;

    user: User = new User();

    get metadata(): Metadata {
        return {
            ignore: [],
            view: [],
            comments: {},
            deniedById: {},
            deniedReason: {},
            email: {},
            firstName: {},
            internalComments: {},
            lastName: {},
            location: {},
            orderDate: {},
            orderNumber: {},
            orderProcessDate: {},
            orderStatusId: {},
            phoneExtension: {},
            pickedById: {},
            pickedDate: {},
            userId: {}
        };
    }

    get customerName(): string {
        return this.user.fullName;
    }
}

export class Orders extends Collection<Order> {

    constructor() {
        super(Order);
    }

    get queryModel(): OrdersSearch {
        return OrdersSearch.Build(this);
    }

    get queryString(): string {
        return QueryModel.BuildQueryString(this.queryModel);
    }

    get searchResults(): Order[] {
        return this.filterBy(x => x.id !== 0);
    }
}

export class OrderRow {

    constructor(private _order: Order) {
    }

    get order(): Order {
        return build(Order, this._order);
    }

    get orderDate(): Date {
        return new Date(this.order.orderDate);
    }

    get orderId(): number {
        return this.order.id;
    }

    get orderNumber(): number {
        return this.order.orderNumber;
    }

    get customerName(): string {
        return this.order.customerName;
    }
}

export class OrdersSearch extends QueryModel<Order> {

    orders: Orders = new Orders();

    static Build(orders: Orders): OrdersSearch {
        return build(OrdersSearch, { orders });
    }

    static Params(orders: Orders): any {
        return {};
    }

    get params(): any {
        return OrdersSearch.Params(this.orders);
    }

    set params(value: any) {
    }

}
