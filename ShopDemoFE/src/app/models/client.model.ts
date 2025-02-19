import { IItem } from "./Item.model";

export interface IClientModel {
  id?: string;
  clientItem?: IClientItem[];
  name?: string;
  lastName?: string;
  address?: string;
}

export interface IClientItem {
  ItemId: string;
  Item?: IItem;
  DateAdded: Date
}