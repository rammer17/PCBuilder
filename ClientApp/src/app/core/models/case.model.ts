export type CaseGetResponse = {
  id: number;
  manufacturer: string;
  model: string;
  type: string;
  formFactor: string;
  maxGpuHeight: number;
  maxGpuWidth: number;
}[];

export type CaseGetCompatibleRequest = {
  motherboardId: number;
  powerSupplyId: number;
  gpuId: number;
};

export type CaseAddRequest = {
  manufacturer: string;
  model: string;
  type: string;
  formFactor: string;
  maxGpuHeight: number;
  maxGpuWidth: number;
};
