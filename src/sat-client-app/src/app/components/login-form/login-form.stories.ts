import { storiesOf } from '@storybook/angular';
import { LoginFormComponent } from './login-form.component';

storiesOf('My Button', module)
  .add('with some emoji', () => ({
    component: LoginFormComponent,
    props: {
      text: '',
    },
    moduleMetadata: {
      //imports: [forms here],
    }
  }));
