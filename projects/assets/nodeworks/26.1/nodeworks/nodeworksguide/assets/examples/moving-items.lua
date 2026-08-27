local input = network:get("input")
local output = network:get("output")

local allItems = input:find("*") -- get all the items in this container
if allItems then -- if we found any items
	output:insert(allItems)
end
