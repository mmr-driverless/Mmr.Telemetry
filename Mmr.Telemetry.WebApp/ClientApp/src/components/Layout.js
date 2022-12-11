import React, { Component } from 'react';
import { Container } from 'reactstrap';
import {Navbar} from './Navbar';

export class Layout extends Component {
  static displayName = Layout.name;

  render() {
    return (
      <>
        <Navbar />
        <Container>
          {this.props.children}
        </Container>
      </>
    );
  }
}
