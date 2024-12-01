import React from 'react';
import {
  Table,
  TableBody,
  TableCell,
  TableContainer,
  TableHead,
  TableRow,
  Paper,
  Select,
  MenuItem,
  Typography,
  FormControl,
  InputLabel,
  Button,
} from '@mui/material';
import styled from 'styled-components';
import { Formik, Field, Form, ErrorMessage } from 'formik';
import * as Yup from 'yup';

// Estilo personalizado para el botón
const StyledButton = styled.button`
  align-self: flex-end;
  margin-top: 10px;  
  padding: 8px 16px;
  background-color: #1976d2;
  color: #fff;
  border: none;
  border-radius: 4px;
  cursor: pointer;
  font-size: 14px;
  
  &:disabled {
    background-color: #cccccc;
    cursor: not-allowed;
  }

  &:hover:not(:disabled) {
    background-color: #1565c0;
  }

  @media (max-width: 600px) {
    width: 100%;
    align-self: stretch;  
  }
`;

// Contenedor principal
const StyledContainer = styled.div`
  display: flex;
  flex-direction: column;
`;

// Contenedor para el label y el botón
const FooterContainer = styled.div`
  display: flex;
  justify-content: space-between;
  align-items: center;
  margin-top: 10px;
  
  // Cuando el tamaño es xs, poner todo en una sola columna y el botón a full width
  @media (max-width: 600px) {
    flex-direction: column;
    align-items: stretch; // Asegura que el botón ocupe todo el ancho
  }
`;
//Label personalizado
const StyledLabel = styled.span`
  font-size: 14px;
  background-color: rgba(25, 118, 210, 0.3);
  padding: 5px 10px;
  border-radius: 12px;
  display: inline-block;
  width: fit-content;
  margin: 5px;
`;
//Contenedor para el mensaje al no haber articulos
const MessageContainer = styled.div`
  text-align: center;
  color: #666;
  margin-top: 20px;
  border: 2px solid rgba(25, 118, 210, 0.3);
  padding: 50px;
  border-radius: 15px;
  margin: 10px;
`;

const ArticleTable = ({
  articles,
  sellers,
  handleArticleSelect,
  handleSave,
  selectedSeller,
  setSelectedSeller,
  selectedArticles,
}) => {
  // Validación con Yup
  const validationSchema = Yup.object().shape({
    seller: Yup.string().required('Debe seleccionar un vendedor'),
    articles: Yup.array().min(1, 'Debe seleccionar al menos un artículo'),
  });

  // Función para calcular el total de los precios de los artículos seleccionados
  const calculateTotal = (selectedArticles) => {
    return selectedArticles.reduce((total, article) => total + article.precio, 0);
  };

  return (
    <Formik
      initialValues={{
        seller: selectedSeller,
        articles: selectedArticles,
      }}
      validationSchema={validationSchema}
      onSubmit={(values) => {
        console.log(values);
        handleSave(values);
      }}
    >
      {({ setFieldValue, values, errors, touched }) => (
        <StyledContainer>

          <Form>
            <FormControl
              sx={{
                margin: 2,
                width: {
                  xs: '40%',
                  md: '30%',
                },
              }}
            >
              <InputLabel id="seller-label">
                <Typography>Vendedor</Typography>
              </InputLabel>
              <Field
                name="seller"
                render={({ field }) => (
                  <Select
                    {...field}
                    labelId="seller-label"
                    value={values.seller}
                    onChange={(e) => setFieldValue('seller', e.target.value)}
                  >
                    {sellers.length ? (
                      sellers.map((seller) => (
                        <MenuItem key={seller.id} value={seller.id}>
                          {seller.descripcion}
                        </MenuItem>
                      ))
                    ) : (
                      <MenuItem>No hay vendedores</MenuItem>
                    )}
                  </Select>
                )}
              />
              {errors.seller && touched.seller && (
                <Typography color="error">{errors.seller}</Typography>
              )}
            </FormControl>

            {articles.length === 0 ? (
              <MessageContainer>
                <Typography>No hay artículos disponibles</Typography>
              </MessageContainer>
            ) : (
              <TableContainer
                component={Paper}
                sx={{ border: '1px solid rgba(25, 118, 210, 0.3)' }}
              >
                <Table>
                  <TableHead>
                    <TableRow>
                      <TableCell>Seleccionar</TableCell>
                      <TableCell>Código</TableCell>
                      <TableCell>Descripción</TableCell>
                      <TableCell>Precio</TableCell>
                      <TableCell>Depósito</TableCell>
                    </TableRow>
                  </TableHead>
                  <TableBody>
                    {articles.map((article) => (
                      <TableRow key={article.codigo}>
                        <TableCell>
                          <input
                            type="checkbox"
                            checked={values.articles.includes(article)}
                            onChange={(event) => {
                              const updatedArticles = event.target.checked
                                ? [...values.articles, article]
                                : values.articles.filter((a) => a !== article);
                              setFieldValue('articles', updatedArticles);
                            }}
                          />
                        </TableCell>
                        <TableCell>{article.codigo}</TableCell>
                        <TableCell>{article.descripcion}</TableCell>
                        <TableCell>{article.precio}</TableCell>
                        <TableCell>{article.deposito}</TableCell>
                      </TableRow>
                    ))}
                  </TableBody>
                </Table>
              </TableContainer>
            )}

            <FooterContainer>
              <StyledLabel>
                <Typography variant="body2">
                  {values.articles.length
                    ? `Artículos seleccionados: ${values.articles.length}`
                    : 'Debe seleccionar al menos un artículo'}
                </Typography>
              </StyledLabel>
              <StyledLabel>
                <Typography variant="body2">
                  {values.articles.length
                    ? `Total Precio: $${calculateTotal(values.articles).toFixed(2)}`
                    : 'Total Precio: $0'}
                </Typography>
              </StyledLabel>
              <StyledButton type="submit" >
                <Typography>Guardar Pedido</Typography>
              </StyledButton>
            </FooterContainer>
          </Form>
        </StyledContainer>
      )}
    </Formik>
  );
};

export default ArticleTable;
