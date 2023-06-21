import { CaseGetResponse } from './case.model';
import { CpuCoolerGetResponse } from './cpu-cooler.model';
import { CpuGetResponse } from './cpu.model';
import { GpuGetResponse } from './gpu.model';
import { MotherboardGetResponse } from './motherboard.model';
import { PowerSupplyGetResponse } from './power-supply.model';
import { RamGetResponse } from './ram.model';
import { StorageGetResponse } from './storage.model';

export type PCComponent =
  | (BaseComponent & CpuGetResponse)
  | (BaseComponent & CpuCoolerGetResponse)
  | (BaseComponent & MotherboardGetResponse)
  | (BaseComponent & RamGetResponse)
  | (BaseComponent & StorageGetResponse)
  | (BaseComponent & GpuGetResponse)
  | (BaseComponent & CaseGetResponse)
  | (BaseComponent & PowerSupplyGetResponse);

type BaseComponent = {
  manufacturer: string;
  model: string;
  imageUrl: string;
};
