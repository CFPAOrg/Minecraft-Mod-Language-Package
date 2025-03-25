### 总概

```mermaid
flowchart LR
    1.20.1 -->|indirect| 1.19.2 -->|indirect| 1.18.2
    1.19.2 -->|singleton| 1.18.2
    1.19.2 -->|composition| 1.18.2
    1.18.2 -->|indirect| 1.18.2-fabric & 1.16.5
    1.18.2 -->|composition| 1.18.2-fabric & 1.16.5
    1.20.1-fabric -->|indirect| 1.19.2-fabric
    linkStyle 2 color:crimson,stroke:crimson
    linkStyle 3,6,7 color:royalblue,stroke:royalblue
```

```
1.20.1
 └── 1.19.2 (singleton)(composition)
      └── 1.18.2 (composition)
           ├── 1.18.2-fabric (singleton)
           └── 1.16.5
1.20.1-fabric
 └── 1.19.2-fabric (singleton)(composition)
```

### 链接区域

- [1.16.5](/projects/1.16/assets/macaws-roofs-oh-the-biomes-youll-go/macawsroofsbyg)
- [1.18.2](/projects/1.18/assets/macaws-roofs-oh-the-biomes-youll-go/macawsroofsbyg)
- [1.19.2](/projects/1.19/assets/macaws-roofs-oh-the-biomes-youll-go/macawsroofsbyg)
- [1.20.1](/projects/1.20/assets/macaws-roofs-oh-the-biomes-youll-go/macawsroofsbyg)
- [1.18.2-fabric](/projects/1.18-fabric/assets/macaws-roofs-oh-the-biomes-youll-go/macawsroofsbyg)
- [1.19.2-fabric](/projects/1.19/assets/macaws-roofs-oh-the-biomes-youll-go/z_mcwroofsbyg)
- [1.20.1-fabric](/projects/1.20-fabric/assets/macaws-roofs-oh-the-biomes-youll-go/z_mcwroofsbyg)