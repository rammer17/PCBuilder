export type StorageGetResponse = {
  Id: number;
  Manufacturer: string;
  Model: string;
  Type: string;
  Capacity: number;
  FormFactor: string;
  ReadSpeed: number;
  WriteSpeed: number;
  Interface: string;
}[];

export type StorageAddRequest = {
  Manufacturer: string;
  Model: string;
  Type: string;
  Capacity: number;
  FormFactor: string;
  ReadSpeed: number;
  WriteSpeed: number;
  Interface: string;
};
