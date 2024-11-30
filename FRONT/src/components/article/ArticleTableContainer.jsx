import React, { useEffect, useState } from 'react';
import ArticleTable from './ArticleTable';
import axiosInstance from '../../axios/axios.js';
import { CircularProgress } from '@mui/material';
import styled from 'styled-components';

// Contenedor estilizado para centrar los elementos
const Container = styled.div`
  display: flex;
  justify-content: center;
  align-items: center;
  padding: 20px;
  height: 50vh;
`;

const ArticleTableContainer = () => {
  const [sellers, setSellers] = useState([]); // Lista de vendedores
  const [selectedArticles, setSelectedArticles] = useState([]); // Artículos seleccionados
  const [selectedSeller, setSelectedSeller] = useState(''); // Vendedor seleccionado
  const [articles, setArticles] = useState([]); // Lista de artículos
  const [loading, setLoading] = useState(true); // Estado de carga
  
  useEffect(() => {
    const fetchData = async () => {
      try {
        // Cargar artículos y vendedores en paralelo
        const [articlesResponse, sellersResponse] = await Promise.all([
          axiosInstance.get('/articulos'),
          axiosInstance.get('/vendedores'),
        ]);
        
        setArticles(articlesResponse.data);
        setSellers(sellersResponse.data);
      } catch (error) {
        console.error("Error al obtener los datos:", error);
      } finally {
        setLoading(false); // Una vez cargados los datos, cambiar el estado de carga a false
      }
    };

    fetchData();
  }, []);

  const handleArticleSelect = (event, article) => {
    const updatedSelected = [...selectedArticles];
    if (event.target.checked) {
      updatedSelected.push(article);
    } else {
      updatedSelected.splice(updatedSelected.indexOf(article), 1);
    }
    setSelectedArticles(updatedSelected);
  };

  const handleSave = () => {
    // Lógica para guardar el pedido
    console.log('Pedido a guardar:', {
      seller: selectedSeller,
      articles: selectedArticles
    });
  };

  return (
    <>
      {loading ? (
        <Container>
            <CircularProgress />
        </Container> 
      ) : (
        <ArticleTable
          sellers={sellers}
          articles={articles}
          handleSave={handleSave}
          handleArticleSelect={handleArticleSelect}
          selectedSeller={selectedSeller}
          setSelectedSeller={setSelectedSeller}  // Pasamos el setter para actualizar el vendedor seleccionado
          selectedArticles={selectedArticles}  // Pasamos los artículos seleccionados
        />
      )}
    </>
  );
};

export default ArticleTableContainer;
