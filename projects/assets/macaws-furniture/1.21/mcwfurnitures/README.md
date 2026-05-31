### 总概

```mermaid
flowchart LR
    1.21.1 -->|indirect| 1.21.1-fabric
    1.20.1 -->|indirect| 1.20.1-fabric
    1.21.1 -->|indirect| 1.19.2/1.19.2-fabric -->|indirect| 1.18.2 -->|indirect| 1.18.2-fabric
    1.19.2/1.19.2-fabric -->|singleton| 1.18.2
    1.18.2 -->|indirect| 1.16.5
    1.21.1 -->|indirect| 1.20.1
    linkStyle 5 color:crimson,stroke:crimson
```

```
1.21.1
 ├── 1.21.1-fabric
 ├── 1.20.1
 │    └── 1.20.1-fabric
 └── 1.19.2/1.19.2-fabric (singleton)
      ├── 1.18.2
      │    └── 1.18.2-fabric
      └── 1.16.5 (singleton)
```

### 链接区域

- [1.16.5](/projects/assets/macaws-furniture/1.16/mcwfurnitures)
- [1.18.2](/projects/assets/macaws-furniture/1.18/mcwfurnitures)
- [1.19.2](/projects/assets/macaws-furniture/1.19/mcwfurnitures)
- [1.20.1](/projects/assets/macaws-furniture/1.20/mcwfurnitures)
- [1.21.1](/projects/assets/macaws-furniture/1.21/mcwfurnitures)
- [1.18.2-fabric](/projects/assets/macaws-furniture/1.18-fabric/mcwfurnitures)
- [1.20.1-fabric](/projects/assets/macaws-furniture/1.20-fabric/mcwfurnitures)
- [1.21.1-fabric](/projects/assets/macaws-furniture/1.21-fabric/mcwfurnitures)