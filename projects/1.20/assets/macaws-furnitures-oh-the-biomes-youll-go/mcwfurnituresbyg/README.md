### 总概

```mermaid
flowchart LR
    1.20.1 -->|indirect| 1.20.1-fabric
    1.20.1 -->|indirect| 1.19.2/1.19.2-fabric -->|indirect| 1.18.2 -->|indirect| 1.16.5
    1.19.2/1.19.2-fabric -->|composition| 1.18.2 -->|composition| 1.16.5
    linkStyle 4,5 color:royalblue,stroke:royalblue
```

```
1.20.1
 ├── 1.20.1-fabric
 └── 1.19.2 (composition)
      └── 1.18.2 (composition)
           └── 1.16.5
```

### 链接区域

- [1.16.5](/projects/1.16/assets/macaws-furnitures-oh-the-biomes-youll-go/mcwfurnituresbyg)
- [1.18.2](/projects/1.18/assets/macaws-furnitures-oh-the-biomes-youll-go/mcwfurnituresbyg)
- [1.19.2](/projects/1.19/assets/macaws-furnitures-oh-the-biomes-youll-go/mcwfurnituresbyg)
- [1.20.1](/projects/1.20/assets/macaws-furnitures-oh-the-biomes-youll-go/mcwfurnituresbyg)
- [1.19.2-fabric](/projects/1.19/assets/macaws-furnitures-oh-the-biomes-youll-go/mcwfurnituresbyg)
- [1.20.1-fabric](/projects/1.20-fabric/assets/macaws-furnitures-oh-the-biomes-youll-go/mcwfurnituresbyg)