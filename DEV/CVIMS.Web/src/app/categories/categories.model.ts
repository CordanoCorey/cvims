import { Collection, build, toInt } from '@caiu/core';

export class Category {
    id = 0;
    label = '';
    description = '';
    locationId = 0;

    get name(): string {
        return this.label.toLowerCase().replace(/\s+/g, '-');
    }

    get params(): any {
        return {
            categoryId: this.id
        };
    }

    get url(): string {
        return `/products?category=${this.name}`;
    }

    get width(): string {
        return `${this.widthPx}px`;
    }

    get widthPx(): number {
        return this.label.length * 8 + 20;
    }

}

export class Categories extends Collection<Category> {

    activateByName(categoryName: string): Categories {
        const activeCategory = build(Category, this.findBy(x => x.name === categoryName));
        return build(Categories, this.activate(toInt(activeCategory.id)));
    }

    get categoryName(): string {
        return this.get(this.activeId).label;
    }

    constructor() {
        super(Category);
    }

    getCategoryLabel(categoryId: number): string {
        const category = this.get(categoryId);
        return category.label || 'All';
    }

}
