// import { storiesOf } from '@storybook/angular';
// import { LoginFormComponent } from '../app/components/login-form/login-form.component';

// storiesOf('My Button', module)
//   .add('with some emoji', () => ({
//     component: LoginFormComponent,
//     props: {
//       text: '😀 😎 👍 💯',
//     },
//   }));

//import { configure } from '@storybook/vue'

import { storiesOf, configure } from '@storybook/angular';

const req = require.context('../app/components', true, /\.stories\.ts$/)
function loadStories() {
  return req.keys().forEach((filename) => req(filename));
}
////////////////const x = loadStories();

//storiesOf(x, module);

configure(loadStories, module)
