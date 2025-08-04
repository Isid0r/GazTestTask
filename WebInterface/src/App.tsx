import { Container, Grid } from "@mui/material";
import { OffersTable } from "./components/OffersTable";
import { TopSuppliersTable } from "./components/TopSupplierTable";

function App() {
  return (
    <Container sx={{ py: 4 }}>
      <Grid container spacing={4}>
        <Grid size={{ xs: 12, md: 4 }}>
          <TopSuppliersTable />
        </Grid>
        <Grid size={{ xs: 12, md: 8 }}>
          <OffersTable />
        </Grid>
      </Grid>
    </Container>
  );
}

export default App;
