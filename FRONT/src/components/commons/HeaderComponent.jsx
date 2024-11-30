import React from 'react';
import styled from 'styled-components';
import AppBar from '@mui/material/AppBar';
import Toolbar from '@mui/material/Toolbar';
import logo from '/logoSuris.png';

const StyledImage = styled.img`
  height: 40px;
`;

const HeaderComponent = () => {
  return (
    <AppBar position="static">
      <Toolbar>
        <StyledImage src={logo} alt="Logo" />
      </Toolbar>
    </AppBar>
  );
};

export default HeaderComponent;