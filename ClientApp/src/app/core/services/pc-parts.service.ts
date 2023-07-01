import { Injectable } from '@angular/core';
import { FormGroup } from '@angular/forms';

@Injectable({
  providedIn: 'root'
})
export class PcPartsService {
  resetForm(form: FormGroup): void {
    form.reset({
      manufacturer: form.get('manufacturer')?.value,
    });
    form.controls['gpu'].reset({
      memoryType: '',
    });
    form.controls['cpuCooler'].reset({
      socketIds: '',
      type: '',
    });
    form.controls['cpu'].reset({
      socketId: '',
    });
  }
}
