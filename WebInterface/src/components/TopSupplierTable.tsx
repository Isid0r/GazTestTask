import {
  Card,
  CardContent,
  Typography,
  TableContainer,
  Paper,
  Table,
  TableHead,
  TableRow,
  TableCell,
  TableBody,
  Box,
  Chip,
} from "@mui/material";
import { useGetPopularSuppliersQuery } from "../services/api";
import { LoadingErrorHandler } from "./LoadingErrorHandler";

export const TopSuppliersTable = () => {
  const { data, isLoading, error } = useGetPopularSuppliersQuery();

  return (
    <Card elevation={4}>
      <CardContent>
        <Typography variant="h6" component="h2" gutterBottom>
          Топ-3 поставщика
        </Typography>

        <LoadingErrorHandler isLoading={isLoading} error={error}>
          <TableContainer component={Paper} variant="outlined">
            <Table size="small">
              <TableHead>
                <TableRow>
                  <TableCell sx={{ fontWeight: "bold" }}>
                    Наименование
                  </TableCell>
                  <TableCell sx={{ fontWeight: "bold" }} align="right">
                    Количество предложений
                  </TableCell>
                </TableRow>
              </TableHead>
              <TableBody>
                {data && data.length > 0 ? (
                  data.map((supplier) => (
                    <TableRow key={supplier.id}>
                      <TableCell>
                        <Box
                          sx={{ display: "flex", alignItems: "center", gap: 1 }}
                        >
                          {supplier.name}
                        </Box>
                      </TableCell>
                      <TableCell align="right">
                        <Chip label={supplier.offersCount} size="small" />
                      </TableCell>
                    </TableRow>
                  ))
                ) : (
                  <TableRow>
                    <TableCell colSpan={2} align="center" sx={{ py: 4 }}>
                      <Typography variant="body2" color="text.secondary">
                        Нет данных для отображения
                      </Typography>
                    </TableCell>
                  </TableRow>
                )}
              </TableBody>
            </Table>
          </TableContainer>
        </LoadingErrorHandler>
      </CardContent>
    </Card>
  );
};
