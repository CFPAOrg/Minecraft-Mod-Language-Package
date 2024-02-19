# Advanced Cipher Block

![Almost safe.](block:computronics:cipher_advanced)

The advanced cipher block uses RSA encryption by creating a public and private key pair. The key pair can be generated using a pair of prime numbers or randomly. The returned value itself will return both key pairs once it is done generating (which will take a few seconds).
The public key is used to encrypt messages, while the private key is used to decrypt messages. Only devices with access to the private key may decrypt messages.
