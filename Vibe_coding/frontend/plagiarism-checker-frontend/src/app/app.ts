import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-root',
  imports: [FormsModule, CommonModule],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  inputType: string = 'text';
  inputText: string = '';
  results: any = null;

  get canCheck(): boolean {
    return (this.inputType === 'text' && this.inputText.trim().length > 0) || (this.inputType === 'file' && this.fileContent.length > 0);
  }

  private fileContent: string = '';

  onFileSelected(event: any) {
    const file = event.target.files[0];
    if (file) {
      const reader = new FileReader();
      reader.onload = (e) => {
        this.fileContent = e.target?.result as string;
      };
      reader.readAsText(file);
    }
  }

  checkPlagiarism() {
    const text = this.inputType === 'text' ? this.inputText : this.fileContent;
    // Mock results for now
    this.results = {
      score: Math.floor(Math.random() * 100),
      matches: [
        { source: 'Source 1', similarity: Math.floor(Math.random() * 100) },
        { source: 'Source 2', similarity: Math.floor(Math.random() * 100) }
      ]
    };
  }
}
