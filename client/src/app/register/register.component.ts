import {
  Component,
  EventEmitter,
  inject,
  Input,
  input,
  output,
  Output,
} from '@angular/core';
import { FormsModule } from '@angular/forms';
import { AccountService } from '../_services/account.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './register.component.html',
  styleUrl: './register.component.css',
})
export class RegisterComponent {
  /*
  //before angular 17.2 // we use for communication
  @Input() usersFromHomeComponent: any;
    @Output() cancelRegister = new EventEmitter();
  */
  // available new feature input signal onwards 17.3 angular version
  // usersFromHomeComponent = input.required<any>();
  cancelRegister = output<boolean>(); // no need to create event emmitter
  private accountService = inject(AccountService);
  private toastr = inject(ToastrService);
  model: any = {};
  register() {
    this.accountService.register(this.model).subscribe({
      next: (response) => {
        console.log(response);
        this.cancel();
      },
      error: (error) => {
        this.toastr.error(error.error);
        console.log(error);
      },
    });
  }
  cancel() {
    console.log('cancelled');
    this.cancelRegister.emit(false);
  }
}
