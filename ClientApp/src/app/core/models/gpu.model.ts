export type GpuGetResponse = {
  id: number;
  manufacturer: string;
  model: string;
  imageUrl: string;
  baseClock: number;
  maxBoostClock: number;
  memorySize: number;
  memoryType: string;
  memoryBus: number;
  tdp: number;
  height: number;
  width: number;
};

export type GpuGetCompatibleRequest = {
  caseId: number;
};

export type GpuAddRequest = {
  manufacturer: string;
  model: string;
  imageUrl: string;
  baseClock: number;
  maxBoostClock: number;
  memorySize: number;
  memoryType: string;
  memoryBus: number;
  tdp: number;
  height: number;
  width: number;
};
