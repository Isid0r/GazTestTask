import {
  Card,
  CardContent,
  Typography,
  Box,
  TextField,
  TableContainer,
  Paper,
  Table,
  TableHead,
  TableRow,
  TableCell,
  TableBody,
  Chip,
} from "@mui/material";
import { useState, useEffect } from "react";
import { useGetOffersQuery } from "../services/api";
import { LoadingErrorHandler } from "./LoadingErrorHandler";

export const OffersTable = () => {
  const [searchQuery, setSearchQuery] = useState("");
  const [debouncedSearch, setDebouncedSearch] = useState("");

  useEffect(() => {
    const timer = setTimeout(() => {
      setDebouncedSearch(searchQuery);
    }, 500);

    return () => clearTimeout(timer);
  }, [searchQuery]);

  const { data, isLoading, error } = useGetOffersQuery({
    search: debouncedSearch || undefined,
  });

  return (
    <Card elevation={4}>
      <CardContent>
        <Typography variant="h6" component="h2" gutterBottom>
          Предложения
        </Typography>

        <Box sx={{ mb: 3 }}>
          <TextField
            fullWidth
            variant="outlined"
            placeholder="Поиск по марке, модели или поставщику..."
            value={searchQuery}
            onChange={(e) => setSearchQuery(e.target.value)}
            size="small"
          />
        </Box>

        <LoadingErrorHandler isLoading={isLoading} error={error}>
          <TableContainer
            component={Paper}
            variant="outlined"
            sx={{ maxHeight: 400 }}
          >
            <Table>
              <TableHead>
                <TableRow>
                  <TableCell sx={{ fontWeight: "bold" }}>Марка</TableCell>
                  <TableCell sx={{ fontWeight: "bold" }}>Модель</TableCell>
                  <TableCell sx={{ fontWeight: "bold" }}>
                    Дата регистрации
                  </TableCell>
                  <TableCell sx={{ fontWeight: "bold" }}>Поставщик</TableCell>
                </TableRow>
              </TableHead>
              <TableBody>
                {data?.items && data.items.length > 0 ? (
                  data.items.map((offer) => (
                    <TableRow key={offer.id} hover>
                      <TableCell>
                        <Chip
                          label={offer.brand}
                          variant="outlined"
                          size="small"
                        />
                      </TableCell>
                      <TableCell>{offer.model}</TableCell>
                      <TableCell>
                        {new Date(offer.registrationDate).toLocaleString(
                          "ru-RU"
                        )}
                      </TableCell>
                      <TableCell>{offer.supplier.name}</TableCell>
                    </TableRow>
                  ))
                ) : (
                  <TableRow>
                    <TableCell colSpan={4} align="center" sx={{ py: 4 }}>
                      <Typography variant="body2" color="text.secondary">
                        {searchQuery
                          ? "По вашему запросу ничего не найдено"
                          : "Нет данных для отображения"}
                      </Typography>
                    </TableCell>
                  </TableRow>
                )}
              </TableBody>
            </Table>
          </TableContainer>
        </LoadingErrorHandler>

        {data && (
          <Box sx={{ mt: 2 }}>
            <Typography variant="body2" color="text.secondary">
              Найдено: {data.items.length} из {data.totalCount} предложений
            </Typography>
          </Box>
        )}
      </CardContent>
    </Card>
  );
};
