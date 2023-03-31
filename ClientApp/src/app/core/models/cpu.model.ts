export type CpuGetResponse = {
  id: number;
  manufacturer: string;
  model: string;
  cores: number;
  threads: number;
  baseClock: number;
  maxBoostClock: number;
  socket: string;
}[];

export type CpuGetCompatibleRequest = {
  cpuCoolerId: number;
  motherboardId: number;
};

export type CpuAddRequest = {
  manufacturer: string;
  model: string;
  cores: number;
  threads: number;
  baseClock: number;
  maxBoostClock: number;
  socket: string;
};
