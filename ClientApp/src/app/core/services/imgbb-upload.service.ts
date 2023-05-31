import { HttpClient } from "@angular/common/http";
import { Injectable, inject } from "@angular/core";
import { Observable, map } from "rxjs";
@Injectable({
  providedIn: "root",
})
export class ImgbbUploadService {
  //* Injecting Dependencies
  private http: HttpClient = inject(HttpClient);

  private readonly API_KEY = "36b1b5b35f2b526eb066d406a7cce172";

  upload(file: File): Observable<string> {
    const formData = new FormData();
    formData.append("image", file);

    return this.http
      .post("/upload", formData, { params: { key: this.API_KEY }})
      .pipe(map((resp: any) => resp["data"]["url"]));
  }
}
