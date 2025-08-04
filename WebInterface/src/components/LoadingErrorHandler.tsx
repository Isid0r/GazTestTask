import { Box, CircularProgress, Alert } from "@mui/material";
import type { SerializedError } from "@reduxjs/toolkit";
import type { FetchBaseQueryError } from "@reduxjs/toolkit/query";

interface LoadingErrorHandlerProps {
  isLoading: boolean;
  error: FetchBaseQueryError | SerializedError | undefined;
  children: React.ReactNode;
}

export const LoadingErrorHandler = ({
  isLoading,
  error,
  children,
}: LoadingErrorHandlerProps) => {
  if (isLoading) {
    return (
      <Box sx={{ display: "flex", justifyContent: "center", py: 4 }}>
        <CircularProgress />
      </Box>
    );
  }

  if (error) {
    return (
      <Alert severity="error">
        {`Ошибка при загрузке данных: ${JSON.stringify(error)}`}
      </Alert>
    );
  }

  return <>{children}</>;
};
