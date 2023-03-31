export type CpuCoolerGetResponse = {
  id: number;
  manufacturer: string;
  model: string;
  type: string;
  tdp: number;
  sockets: string[];
  maxrpm: number;
  noiseLevel: number;
}[];

export type CpuCoolerGetCompatibleRequest = {
  cpuId: number;
};

export type CpuCoolerAddRequest = {
  manufacturer: string;
  model: string;
  type: string;
  tdp: number;
  socketIds: number[];
  maxrpm: number;
  noiseLevel: number;
};
