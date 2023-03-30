export type CpuCoolerGetResponse = {
  Id: number;
  Manufacturer: string;
  Model: string;
  Type: string;
  TDP: number;
  Sockets: string[];
  MaxRPM: number;
  NoiseLevel: number;
}[];

export type CpuCoolerGetCompatibleRequest = {
  CpuId: number;
};

export type CpuCoolerAddRequest = {
  Manufacturer: string;
  Model: string;
  Type: string;
  TDP: number;
  SocketIds: number[];
  MaxRPM: number;
  NoiseLevel: number;
};
