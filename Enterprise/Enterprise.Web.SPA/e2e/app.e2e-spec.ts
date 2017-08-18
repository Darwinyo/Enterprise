import { InspiniaAngular4Page } from './app.po';

describe('inspinia-angular4 App', () => {
  let page: InspiniaAngular4Page;

  beforeEach(() => {
    page = new InspiniaAngular4Page();
  });

  it('should display welcome message', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('Welcome to app!!');
  });
});
