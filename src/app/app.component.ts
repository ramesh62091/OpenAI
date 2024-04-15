import { Component } from '@angular/core';
import { OpenAIService } from './open-ai.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'UI';
  searchTxtVal: string = '';
    showOutput: boolean = false;
    output: string = '';
    isLoading: boolean = false;
    constructor(private service: OpenAIService) {}

    getResult(text:string) {
        this.isLoading = true;
        this.output = "";
        this.service.getData(text).subscribe(data => {
            this.output = data as string;
            this.showOutput = true;
            this.isLoading = false;
        })
}
}
