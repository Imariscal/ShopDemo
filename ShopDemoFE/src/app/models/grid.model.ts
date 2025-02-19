export interface IGridModel {
    orderId: number,
    headerText: string;
    width: number;
    fieldName: string;
}

export const clientGridCfg: IGridModel[] = [
    {
        orderId: 1,
        headerText: "Name",
        width: 350,
        fieldName: "name"
    },
    {
        orderId: 2,
        headerText: "Last Name",
        width: 150,
        fieldName: "lastName"
    },
    {
        orderId: 3,
        headerText: "Address",
        width: 250,
        fieldName: "address"
    }
]

export const itemGridCfg: IGridModel[] = [
    {
        orderId: 1,
        headerText: "Code",
        width: 250,
        fieldName: "code"
    },
    {
        orderId: 2,
        headerText: "Description",
        width: 150,
        fieldName: "description"
    },
    {
        orderId: 3,
        headerText: "Prize",
        width: 120,
        fieldName: "prize"
    },
    {
        orderId: 3,
        headerText: "Image URL",
        width: 120,
        fieldName: "image"
    },
    {
        orderId: 4,
        headerText: "Stock",
        width: 50,
        fieldName: "stock"
    },
]

export const shopGridCfg: IGridModel[] = [
    {
        orderId: 1,
        headerText: "Shop Name",
        width: 250,
        fieldName: "name"
    },
    {
        orderId: 2,
        headerText: "Address",
        width: 250,
        fieldName: "address"
    } 
]

export const clientItemCfg : IGridModel[] = [
    {
        orderId: 1,
        headerText: "Item Name",
        width: 350,
        fieldName: "item.code"
    },
    {
        orderId: 2,
        headerText: "Description",
        width: 350,
        fieldName: "item.description"
    } 
]

