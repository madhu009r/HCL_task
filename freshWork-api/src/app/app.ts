import { Component, OnInit, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Freshdesk } from './freshdesk';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';


@Component({
  selector: 'app-root',
  imports: [CommonModule, FormsModule],
  templateUrl: './app.html',
  
})
export class App implements OnInit{

  tickets: any[] = [];

  selectedTicket: any | null = null;

  expandedTicketId: number | null = null;

  newTicket = {
    email: '',
    subject: '',
    description: '',
    priority: 1,
    status: 2
  };

  constructor(private fd: Freshdesk) {}



ngOnInit() {
    this.loadTickets();
  }

loadTickets() {
    this.fd.getTickets().subscribe(res => {
      this.tickets = res as any[];
    });
  }

createTicket() {
  // 1️⃣ Basic frontend validation (MANDATORY for Freshdesk)
  if (
    !this.newTicket.email?.trim() ||
    !this.newTicket.subject?.trim() ||
    !this.newTicket.description?.trim()
  ) {
    alert('Email, Subject, and Description are required');
    return;
  }

  // 2️⃣ Build payload EXACTLY as Freshdesk expects
  const payload = {
    email: this.newTicket.email.trim(),
    subject: this.newTicket.subject.trim(),
    description: this.newTicket.description.trim(),
    priority: Number(this.newTicket.priority), // ensure number
    status: Number(this.newTicket.status)       // ensure number
  };

  console.log('POST payload:', payload);

  // 3️⃣ Call Freshdesk API
  this.fd.createTicket(payload).subscribe({
    next: res => {
      console.log('Ticket created successfully:', res);

      // 4️⃣ Refresh list
      this.loadTickets();

      // 5️⃣ Reset form
      this.newTicket = {
        email: '',
        subject: '',
        description: '',
        priority: 1,
        status: 2
      };
    },
    error: err => {
      console.error('Freshdesk POST error:', err.error);
      alert('Failed to create ticket. Check console for details.');
    }
  });
}

toggleDescription(id: number) {
  this.expandedTicketId = this.expandedTicketId === id ? null : id;
}

viewTicket(t: any) {
  this.fd.getTicketById(t.id).subscribe((fullTicket: any) => {
    this.selectedTicket = fullTicket;
    this.expandedTicketId = t.id;
  });
}


   editTicket(ticket: any) {
    console.log('Selected:', this.selectedTicket);
    this.selectedTicket = { ...ticket }; // clone
  }


 updateTicket() {
  if (!this.selectedTicket) return;

  const payload = {
    subject: this.selectedTicket.subject?.trim(),
    description: this.selectedTicket.description?.trim(),

    // 🔴 FORCE NUMBER CONVERSION (CRITICAL)
    priority: Number(this.selectedTicket.priority),
    status: Number(this.selectedTicket.status)
  };

  console.log('PUT payload (fixed):', payload);

  this.fd.updateTicket(this.selectedTicket.id, payload).subscribe({
    next: () => {
      console.log('PUT SUCCESS');
      this.selectedTicket = null;
      this.loadTickets();
    },
    error: err => {
      console.error('PUT ERROR BODY:', err.error);
    }
  });
}



  deleteTicket(id: number) {
    this.fd.deleteTicket(id)
      .subscribe(() => this.loadTickets());
  }
  //protected readonly title = signal('freshWork-api');
}
