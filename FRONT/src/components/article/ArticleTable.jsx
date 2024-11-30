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
  Button,
} from '@mui/material';

const ArticleTable = ({
  articles,
  sellers,
  handleArticleSelect,
  handleSave,
  selectedSeller,
  setSelectedSeller, // Ahora recibimos la función para cambiar el vendedor
  selectedArticles, // Recibimos los artículos seleccionados
}) => {
  return (
    <div>
      <Select
        value={selectedSeller}
        onChange={(e) => setSelectedSeller(e.target.value)} // Usamos el setter para actualizar el vendedor
        sx={{
          margin: 2,
          width: {
            xs: "40%",
            md: "30%",
          }
        }}
      >
        {sellers.map((seller) => (
          <MenuItem key={seller.id} value={seller.id}>
            {seller.descripcion}
          </MenuItem>
        ))}
      </Select>

      <TableContainer component={Paper}>
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
                    checked={selectedArticles.includes(article)} // Verifica si el artículo está seleccionado
                    onChange={(event) => handleArticleSelect(event, article)} // Llama al handler
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

      <Button onClick={handleSave} disabled={!selectedSeller || selectedArticles.length === 0}>
        Guardar Pedido
      </Button>
    </div>
  );
};

export default ArticleTable;
