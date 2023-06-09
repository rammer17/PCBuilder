
export type CpuCoolerGetResponse = {
  id: number;
  manufacturer: string;
  model: string;
  imageUrl: string;
  type: string;
  tdp: number;
  sockets: string[];
  maxRPM: number;
  noiseLevel: number;
};

export type CpuCoolerGetCompatibleRequest = {
  cpuId: number;
};

export type CpuCoolerAddRequest = {
  manufacturer: string;
  model: string;
  imageUrl: string;
  type: string;
  tdp: number;
  socketIds: number[];
  maxRPM: number;
  noiseLevel: number;
};
