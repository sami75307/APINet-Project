import { Component,OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
 title = "the dating app";
 users:any;

 constructor(private http: HttpClient) {}
  ngOnInit(): void {
  this.getUsers();
  }
  getUsers(){
    this.http.get('http:/localhost:5001/api/users').subscribe( res=> 
      {
        this.users=res;
      },
      err => {
        console.log(err);
      },
      () => {
        console.log('users loaded');
      }
       );
    
    }
}
