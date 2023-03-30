export type GpuGetResponse = {
  Id: number;
  Manufacturer: string;
  Model: string;
  BaseClock: number;
  MaxBoostClock: number;
  MemorySize: number;
  MemoryType: string;
  MemoryBus: number;
  TDP: number;
  Height: number;
  Width: number;
}[];

export type GpuGetCompatibleRequest = {
  CaseId: number;
};

export type GpuAddRequest = {
  Manufacturer: string;
  Model: string;
  BaseClock: number;
  MaxBoostClock: number;
  MemorySize: number;
  MemoryType: string;
  MemoryBus: number;
  TDP: number;
  Height: number;
  Width: number;
};
