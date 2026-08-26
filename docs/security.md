# Security & Threat Model

This is an educational simulation. It does not store real private keys, perform real transactions, or communicate with production financial services without explicit configuration.

## Considerations

- Secrets and API keys should be stored in environment variables or a secure vault, never in source control.
- Simulated endpoints are used by default.
- The in-memory provider is not a substitute for encrypted persistent storage.
