export type CpuGetResponse = {
  Id: number;
  Manufacturer: string;
  Model: string;
  Cores: number;
  Threads: number;
  BaseClock: number;
  MaxBoostClock: number;
  Socket: string;
}[];

export type CpuGetCompatibleRequest = {
  CpuCoolerId: number;
  MotherboardId: number;
};

export type CpuAddRequest = {
  Manufacturer: string;
  Model: string;
  Cores: number;
  Threads: number;
  BaseClock: number;
  MaxBoostClock: number;
  Socket: string;
};
