import { CVIMSPage } from './app.po';

describe('seed App', () => {
  let page: CVIMSPage;

  beforeEach(() => {
    page = new CVIMSPage();
  });

  it('should display welcome message', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('Welcome to app!');
  });
});
