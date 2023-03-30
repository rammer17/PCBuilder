export type CaseGetResponse = {
  Id: number;
  Manufacturer: string;
  Model: string;
  Type: string;
  FormFactor: string;
  MaxGpuHeight: number;
  MaxGpuWidth: number;
}[];

export type CaseGetCompatibleRequest = {
  MotherboardId: number;
  PowerSupplyId: number;
  GpuId: number;
};

export type CaseAddRequest = {
  Manufacturer: string;
  Model: string;
  Type: string;
  FormFactor: string;
  MaxGpuHeight: number;
  MaxGpuWidth: number;
};
