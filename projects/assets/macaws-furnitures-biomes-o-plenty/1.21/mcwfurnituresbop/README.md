### 总概

```mermaid
flowchart LR
    1.21.1 -->|indirect| 1.21.1-fabric
    1.20.4 -->|indirect| 1.20.4-fabric
    1.19.2 -->|indirect| 1.18.2 & 1.16.5
    1.19.2 -->|composition| 1.18.2 & 1.16.5
    1.21.1 -->|indirect| 1.20.4 & 1.19.2
    linkStyle 4,5 color:royalblue,stroke:royalblue
```

```
1.21.1
 ├── 1.21.1-fabric
 ├── 1.20.4
 │    └── 1.20.4-fabric (singleton)
 └── 1.19.2 (composition)
      ├── 1.18.2
      └── 1.16.5
```

### 链接区域

- [1.16.5](/projects/assets/macaws-furnitures-biomes-o-plenty/1.16/mcwfurnituresbop)
- [1.18.2](/projects/assets/macaws-furnitures-biomes-o-plenty/1.18/mcwfurnituresbop)
- [1.19.2](/projects/assets/macaws-furnitures-biomes-o-plenty/1.19/mcwfurnituresbop)
- [1.20.4](/projects/assets/macaws-furnitures-biomes-o-plenty/1.20/mcwfurnituresbop)
- [1.21.1](/projects/assets/macaws-furnitures-biomes-o-plenty/1.21/mcwfurnituresbop)
- [1.20.4-fabric](/projects/assets/macaws-furnitures-biomes-o-plenty/1.20-fabric/mcwfurnituresbop)
- [1.21.1-fabric](/projects/assets/macaws-furnitures-biomes-o-plenty/1.21-fabric/mcwfurnituresbop)