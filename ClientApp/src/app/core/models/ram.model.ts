export type RamGetResponse = {
  Id: number;
  Manufacturer: string;
  Model: string;
  Capacity: number;
  Frequency: number;
  Type: string;
  Timing: string;
}[];

export type RamGetCompatibleRequest = {
  MotherboardId: number;
};

export type RamAddRequest = {
  Manufacturer: string;
  Model: string;
  Capacity: number;
  Frequency: number;
  Type: string;
  Timing: string;
};
