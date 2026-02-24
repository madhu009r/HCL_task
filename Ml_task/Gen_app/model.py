import random

class StoryGenerator:
    def __init__(self):
        self.openings = [
            "One quiet evening,",
            "In a world not very different from ours,",
            "Long ago, in a forgotten land,",
            "In the year 2099,",
            "Beyond the mountains and rivers,"
        ]

        self.twists = [
            "everything changed unexpectedly.",
            "the truth began to unfold.",
            "a dangerous secret was revealed.",
            "nothing would ever be the same again.",
            "a mystery started to grow."
        ]

        self.challenges = [
            "There were doubts, fears, and obstacles everywhere.",
            "Many tried to stop it from happening.",
            "The journey became more dangerous with each step.",
            "Enemies appeared from the shadows.",
            "Trust became a rare and fragile thing."
        ]

        self.resolutions = [
            "In the end, courage made the difference.",
            "Finally, the hidden power was understood.",
            "At last, peace was restored.",
            "Eventually, wisdom overcame fear.",
            "And thus, a new beginning emerged."
        ]

    def generate(self, user_input):
        theme = user_input.strip()

        if not theme:
            return "Please enter a theme for the story."

        opening = random.choice(self.openings)
        twist = random.choice(self.twists)
        challenge = random.choice(self.challenges)
        resolution = random.choice(self.resolutions)

        story = f"""
{opening} the story of {theme} began.

{theme.capitalize()} was not ordinary. It carried something mysterious within it.
People whispered about {theme}, unsure whether it was a blessing or a curse.

Then one day, {twist}

{challenge}

But through determination and unexpected alliances, {theme} found its true purpose.

{resolution}

And from that day forward, {theme} was remembered forever.
"""

        return story.strip()