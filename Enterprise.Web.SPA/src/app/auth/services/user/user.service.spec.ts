// import { UserLoginViewModel } from './../../viewmodels/user-login/user-login.viewmodel';
// import { UserLoginModel } from './../../models/user/user-login/user-login.model';
// /* tslint:disable:no-unused-variable */

// import { TestBed, async, inject } from '@angular/core/testing';
// import { UserService } from './user.service';

// describe('Service: User', () => {
//   let userLoginModel: UserLoginModel;
//   let userLoginViewModel: UserLoginViewModel;
//   beforeEach(() => {
//     TestBed.configureTestingModule({
//       providers: [
//         MockBackend,
//         BaseRequestOptions,
//         UserService]
//     });
//     userLoginModel = <UserLoginModel>{
//       userLogin: 'Test',
//       email: 'test@test.com',
//       phoneNumber: 11111111,
//       password: 'p@ssw0rd'
//     }
//   });
//   afterEach(() => {
//     userLoginModel = null;
//     userLoginViewModel = null;
//   })
//   it('should register user'), inject([UserService], (service: UserService) => {
//     expect(service.userRegistration(userLoginModel).map(x => x.result)).toBeTruthy();
//   });
//   it('check email exist db should return true', inject([UserService], (service: UserService) => {
//     expect(service.checkEmail(userLoginModel.email)).toBeTruthy();
//   }));
//   it('check phone exist db should return true', inject([UserService], (service: UserService) => {
//     expect(service.checkPhone(userLoginModel.phoneNumber.toString())).toBeTruthy();
//   }));
//   it('check userLogin exist db should return true', inject([UserService], (service: UserService) => {
//     expect(service.checkUserLogin(userLoginModel.userLogin)).toBeTruthy();
//   }));
//   it('should login user'), inject([UserService], (service: UserService) => {
//     userLoginViewModel = <UserLoginViewModel>{
//       userLogin: userLoginModel.userLogin,
//       password: userLoginModel.password
//     }
//     expect(service.userLogin(userLoginViewModel).map(x => x.isLogged)).toBeTruthy();
//   })

//   it('should delete user'), inject([UserService], (service: UserService) => {
//     expect(service.deleteUser(userLoginModel.userLogin)).toHaveBeenCalled()
//   });
// });
