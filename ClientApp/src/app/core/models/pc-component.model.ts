import { CaseGetResponse } from './case.model';
import { CpuCoolerGetResponse } from './cpu-cooler.model';
import { CpuGetResponse } from './cpu.model';
import { GpuGetResponse } from './gpu.model';
import { MotherboardGetResponse } from './motherboard.model';
import { PowerSupplyGetResponse } from './power-supply.model';
import { RamGetResponse } from './ram.model';
import { StorageGetResponse } from './storage.model';

export type PCComponent =
  | CpuGetResponse
  | CpuCoolerGetResponse
  | MotherboardGetResponse
  | RamGetResponse
  | StorageGetResponse
  | GpuGetResponse
  | CaseGetResponse
  | PowerSupplyGetResponse;
