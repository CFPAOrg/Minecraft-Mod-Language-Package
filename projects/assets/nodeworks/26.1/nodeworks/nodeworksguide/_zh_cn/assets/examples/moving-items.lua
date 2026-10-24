local input = network:get("input")
local output = network:get("output")

local allItems = input:find("*") -- 抽取此容器中的所有物品
if allItems then -- 如果找到了物品
	output:insert(allItems)
end
