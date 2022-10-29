extends Label


func show_score(meta: SimplePongMeta):
	var score_text = ""
	var first_loop = true

	for player in meta.player_list:
		if first_loop:
			first_loop = false
		else:
			score_text = "%s - " % score_text
		score_text = "%s%d" % [score_text, player.score]
	self.text = score_text
